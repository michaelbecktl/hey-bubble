import { Text, StyleSheet } from 'react-native'

type Props = {
  text: string
  type: 'basic' | 'sub'
}

function AppText({ text, type }: Props) {
  return <Text style={styles[type]}>{text}</Text>
}

const styles = StyleSheet.create({
  basic: {
    color: '#0D0628',
  },
  sub: {
    color: '#242424ff',
  },
})

export default AppText
