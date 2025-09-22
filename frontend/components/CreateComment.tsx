import { Colors } from '@/constants/Colors'
import { UserProfile } from '@/models/models'
import { StyleSheet, View, TextInput } from 'react-native'
import ProfilePhoto from './ProfilePhoto'
import { useState } from 'react'
import BadgeButton from './BadgeButton'
import { useUser } from '@/client/hooks/user'

type Props = {
  autoFocus: boolean
}

function CreateComment({ autoFocus }: Props) {
  const [text, onChangeText] = useState('')
  const user = useUser()

  if (user.isPending) return

  const currentUser = user.data

  return (
    <>
      <View style={styles.container}>
        <View style={styles.photo}>
          <ProfilePhoto source={currentUser.profilePhoto} type="small" />
        </View>
        <View style={styles.textContainer}>
          <TextInput
            style={[styles.textField, text === '' && styles.placeholder]}
            placeholder="Write a comment!"
            value={text}
            onChangeText={onChangeText}
            multiline={true}
            autoFocus={autoFocus}
          />
        </View>
        <View style={styles.buttonContainer}>
          <BadgeButton
            position="topRight"
            size={20}
            borderless={true}
            type="send"
            onPress={() => {}}
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
    flexGrow: 5,
  },
  buttonContainer: { marginTop: 5 },
  textField: {
    fontSize: 13,
    color: Colors.text,
    borderRadius: 5,
    height: 32,
    marginVertical: 5,
  },
  placeholder: {
    color: Colors.subText,
  },
})

export default CreateComment
