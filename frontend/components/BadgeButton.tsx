import { Pressable, StyleSheet, View } from 'react-native'
import Feather from '@expo/vector-icons/Feather'

type Props = {
  position?: 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight'
  type?: 'x' | 'plus' | 'send' | 'phone' | 'search'
  onPress: () => void
}

export default function ExitButton({
  position = 'topLeft',
  type = 'x',
  onPress,
}: Props) {
  const iconColor = '#DB6B85',
    activeIconColor = '#D44976'

  return (
    <View style={[styles.container, styles[position]]}>
      <Pressable
        onPress={onPress}
        style={({ pressed }) => [styles.button, pressed && styles.activeButton]}
      >
        {(pressed) => (
          <Feather
            name={type}
            size={24}
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
    borderColor: '#DB6B85',
    borderWidth: 3,
    padding: 5,
    backgroundColor: '#F7DEE4',
  },
  activeButton: {
    borderColor: '#D44976',
    backgroundColor: '#F3CDD6',
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
