import { Pressable, StyleSheet, Text, View } from 'react-native'

type Props = {
  label: string
  size?: string
  theme?: string
  onPress: () => void
}

export default function AppButton({ label, size, theme, onPress }: Props) {
  if (size === 'large') {
    return (
      <View>
        <Pressable
          onPress={onPress}
          style={[styles.button, { width: 200, height: 64, padding: 16 }]}
        >
          <Text style={[styles.text, { fontSize: 24 }]}>{label}</Text>
        </Pressable>
      </View>
    )
  }

  return (
    <View>
      <Pressable onPress={onPress} style={styles.button}>
        <Text style={styles.text}>{label}</Text>
      </Pressable>
    </View>
  )
}

const styles = StyleSheet.create({
  button: {
    borderRadius: 8,
    padding: 8,
    width: 120,
    height: 45,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#DA627D',
  },
  text: {
    color: 'white',
    fontSize: 16,
    fontWeight: 'bold',
  },
})
