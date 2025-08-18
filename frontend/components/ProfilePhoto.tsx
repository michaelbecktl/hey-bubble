import { Image } from 'expo-image'
import { StyleSheet } from 'react-native'

interface Props {
  source?: string | null
  type: 'post'
}

function ProfilePhoto({ source, type }: Props) {
  const stockImage = require('@/assets/images/profile.png')

  return <Image source={source ? source : stockImage} style={styles[type]} />
}

const styles = StyleSheet.create({
  post: {
    width: 30,
    height: 30,
    borderRadius: '50%',
  },
})

export default ProfilePhoto
