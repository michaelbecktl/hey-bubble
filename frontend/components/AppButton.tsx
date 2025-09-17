import { Colors } from '@/constants/Colors'
import { Pressable, StyleSheet, Text, View } from 'react-native'

type Props = {
  label: string
  size?: 'small' | 'medium' | 'large'
  theme?: string
  onPress: () => void
}

export default function AppButton({
  label,
  size = 'medium',
  theme,
  onPress,
}: Props) {
  return (
    <View>
      <Pressable
        onPress={onPress}
        style={({ pressed }) => [
          styles.button,
          styleSize[size].button,
          pressed && styles.activeButton,
        ]}
      >
        {({ pressed }) => (
          <Text
            style={[
              styles.text,
              styleSize[size].text,
              ,
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
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: Colors.secondary,
  },
  text: {
    color: Colors.background,
    fontSize: 16,
    fontWeight: 'bold',
  },

  activeButton: {
    backgroundColor: Colors.activeSecondary,
  },
  activeText: {
    color: Colors.themeBackground,
  },
})

const styleSize = {
  small: StyleSheet.create({
    button: { width: 60, height: 32, padding: 2 },
    text: {
      fontSize: 16,
    },
  }),
  medium: StyleSheet.create({
    button: { width: 120, height: 45, padding: 8 },
    text: {
      fontSize: 12,
    },
  }),

  large: StyleSheet.create({
    button: { width: 200, height: 64, padding: 16 },
    text: {
      fontSize: 24,
    },
  }),
}
