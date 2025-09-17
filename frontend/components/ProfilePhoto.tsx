import { Image } from 'expo-image'
import { StyleSheet } from 'react-native'

interface Props {
  source?: string | null
  type: 'small' | 'medium' | 'large'
}

function ProfilePhoto({ source, type }: Props) {
  const stockImage = require('@/assets/images/profile.png')

  return <Image source={source ? source : stockImage} style={styles[type]} />
}

const styles = StyleSheet.create({
  small: {
    width: 32,
    height: 32,
    borderRadius: '50%',
  },
  medium: {
    width: 42,
    height: 42,
    borderRadius: '50%',
  },
  large: {
    width: 128,
    height: 128,
    borderRadius: '50%',
  },
})

export default ProfilePhoto
