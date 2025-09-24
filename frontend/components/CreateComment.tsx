import { Colors } from '@/constants/Colors'
import { CommentDTO } from '@/models/models'
import {
  StyleSheet,
  View,
  TextInput,
  KeyboardAvoidingView,
  Platform,
} from 'react-native'
import ProfilePhoto from './ProfilePhoto'
import React, { useState } from 'react'
import BadgeButton from './BadgeButton'
import { useUser } from '@/client/hooks/user'
import { useComment } from '@/client/hooks/comment'

type Props = {
  postId: number
  autoFocus: boolean
}

function CreateComment({ postId, autoFocus }: Props) {
  const [text, onChangeText] = useState('')
  const user = useUser()
  const comment = useComment(postId)

  if (user.isPending || comment.isPending) return

  const currentUser = user.data

  async function handleComment() {
    if (text === '') return
    const content: CommentDTO = {
      postId: postId,
      content: text,
      mediaType: null,
      mediaUrl: null,
    }
    await comment.useCreateComment.mutateAsync(content)
    onChangeText('')
  }

  return (
    <>
      <KeyboardAvoidingView
        style={styles.container}
        behavior={Platform.OS === 'ios' ? 'padding' : 'height'}
        keyboardVerticalOffset={55}
      >
        <View style={styles.padding}>
          <View style={styles.photo}>
            <ProfilePhoto source={currentUser.profilePhoto} type="small" />
          </View>
          <View style={styles.textContainer}>
            <TextInput
              style={[styles.textField]}
              placeholder="Write a comment!"
              placeholderTextColor={Colors.subText}
              value={text}
              onChangeText={onChangeText}
              multiline={true}
              autoFocus={autoFocus}
            />
          </View>
          <View style={styles.buttonContainer}>
            <BadgeButton
              size={24}
              borderless={true}
              type="send"
              onPress={handleComment}
            />
          </View>
        </View>
      </KeyboardAvoidingView>
    </>
  )
}

const styles = StyleSheet.create({
  container: {
    position: 'absolute',
    justifyContent: 'center',
    flexDirection: 'row',
    bottom: 0,
    left: 0,
    right: 0,
  },
  padding: {
    flex: 1,
    flexDirection: 'row',
    backgroundColor: Colors.background,
    paddingHorizontal: 5,
    paddingTop: 10,
    paddingBottom: 45,
  },
  photo: {
    marginRight: 3,
    flex: 1,
    marginVertical: 'auto',
    alignItems: 'center',
  },
  textContainer: {
    flex: 8,
    height: 42,
    alignItems: 'center',
    flexDirection: 'row',
    backgroundColor: Colors.textfield,
    borderRadius: 15,
  },
  buttonContainer: { flex: 1, marginVertical: 'auto', alignItems: 'center' },
  textField: {
    marginHorizontal: 12,
    marginVertical: 'auto',
    alignItems: 'center',
    fontSize: 16,
    color: Colors.text,
  },
})

export default CreateComment
