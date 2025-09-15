import { usePost } from '@/client/hooks/post'
import { useUser } from '@/client/hooks/user'
import ProfilePhoto from '@/components/ProfilePhoto'
import { Colors } from '@/constants/Colors'
import { UserProfile } from '@/models/models'
import { useState } from 'react'
import { TextInput, StyleSheet, View } from 'react-native'

function CreatePost() {
  const queryPosts = usePost()
  const user = useUser()
  const [text, onChangeText] = useState('')

  if (queryPosts.isPending || user.isPending) return

  return (
    <>
      <View style={styles.container}>
        <View style={styles.photo}>
          <ProfilePhoto source={user.data.profilePhoto} type="small" />
        </View>
        <View style={styles.textContainer}>
          <TextInput
            style={[styles.textField, text === '' && styles.placeholder]}
            placeholder="Post a memory!"
            value={text}
            onChangeText={onChangeText}
            multiline={true}
            autoFocus={true}
          />
        </View>
      </View>
    </>
  )
}

const styles = StyleSheet.create({
  container: {
    backgroundColor: Colors.background,
    justifyContent: 'center',
    flexDirection: 'row',
    marginBottom: 2,
    flex: 1,
    padding: 5,
  },
  photo: { marginRight: 10 },
  textContainer: {
    marginVertical: 5,
    flexGrow: 5,
  },
  textField: {
    fontSize: 13,
    color: Colors.text,
    borderRadius: 5,
    flexGrow: 5,
  },
  placeholder: {
    color: Colors.subText,
  },
})

export default CreatePost
