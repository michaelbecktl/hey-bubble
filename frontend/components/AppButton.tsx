import { Pressable, StyleSheet, Text, View } from 'react-native'

type Props = {
  label: string
  size?: string
  theme?: string
  onPress: () => void
}

export default function AppButton({ label, size, theme, onPress }: Props) {
  return (
    <View>
      <Pressable
        onPress={onPress}
        style={({ pressed }) => [
          styles.button,
          size === 'large' && styles.largeButton,
          pressed && styles.activeButton,
        ]}
      >
        {({ pressed }) => (
          <Text
            style={[
              styles.text,
              size === 'large' && styles.largeText,
              pressed && styles.activeText,
            ]}
          >
            {label}
          </Text>
        )}
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
  largeButton: { width: 200, height: 64, padding: 16 },
  text: {
    color: '#FCF7FA',
    fontSize: 16,
    fontWeight: 'bold',
  },
  largeText: {
    fontSize: 24,
  },
  activeButton: {
    backgroundColor: '#D44976',
  },
  activeText: {
    color: '#F9F0F6',
  },
})
