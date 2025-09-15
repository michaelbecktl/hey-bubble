import { usePost } from '@/client/hooks/post'
import { Colors } from '@/constants/Colors'
import { UserProfile } from '@/models/models'
import { StyleSheet, View, TextInput } from 'react-native'
import ProfilePhoto from './ProfilePhoto'
import { useState } from 'react'

type Props = {
  user: UserProfile
}

function CreatePostBar({ user }: Props) {
  const [text, onChangeText] = useState('')
  return (
    <>
      <View style={styles.container}>
        <View style={styles.photo}>
          <ProfilePhoto source={user.profilePhoto} type="small" />
        </View>
        <View style={styles.textContainer}>
          <TextInput
            style={[styles.textField, text === '' && styles.placeholder]}
            placeholder="Post a memory!"
            value={text}
            onChangeText={onChangeText}
            multiline={true}
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

export default CreatePostBar
