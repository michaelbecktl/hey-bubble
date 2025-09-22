import { Pressable, StyleSheet, View } from 'react-native'
import Feather from '@expo/vector-icons/Feather'
import { Colors } from '@/constants/Colors'

type Props = {
  position?: 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight'
  type?: 'x' | 'plus' | 'send' | 'phone' | 'search'
  margin?: number
  size?: number
  borderless?: boolean
  onPress: () => void
}

export default function ExitButton({
  position = 'topLeft',
  type = 'x',
  margin = 0,
  size = 24,
  borderless = false,
  onPress,
}: Props) {
  const iconColor = Colors.secondary,
    activeIconColor = Colors.activeSecondary

  return (
    <View style={[styles.container, styles[position], { margin: margin }]}>
      <Pressable
        onPress={onPress}
        style={({ pressed }) =>
          borderless ? [] : [styles.button, pressed && styles.activeButton]
        }
      >
        {(pressed) => (
          <Feather
            name={type}
            size={size}
            color={pressed ? activeIconColor : iconColor}
          />
        )}
      </Pressable>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    position: 'absolute',
    alignItems: 'center',
    justifyContent: 'center',
  },
  button: {
    borderRadius: '50%',
    borderColor: Colors.secondary,
    borderWidth: 3,
    padding: 5,
    backgroundColor: Colors.subBackground,
  },
  activeButton: {
    borderColor: Colors.activeSecondary,
    backgroundColor: Colors.activeSubBackground,
  },
  text: {
    color: 'white',
    fontSize: 16,
    fontWeight: 'bold',
  },
  topLeft: {
    top: 0,
    left: 0,
  },
  topRight: {
    top: 0,
    right: 0,
  },
  bottomLeft: {
    bottom: 0,
    left: 0,
  },
  bottomRight: {
    bottom: 0,
    right: 0,
  },
})
