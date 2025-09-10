import { Colors } from '@/constants/Colors'
import { Text, StyleSheet } from 'react-native'

type Props = {
  text: string
  type: 'basic' | 'poster' | 'sub'
}

function AppText({ text, type }: Props) {
  return <Text style={[styles.text, styles[type]]}>{text}</Text>
}

const styles = StyleSheet.create({
  text: {
    display: 'flex',
    color: Colors.text,
  },
  basic: {},
  poster: { fontWeight: '600' },
  sub: {
    color: Colors.subText,
    fontSize: 12,
  },
})

export default AppText
