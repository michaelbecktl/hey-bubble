import { Pressable, StyleSheet, View } from 'react-native'
import Feather from '@expo/vector-icons/Feather'

type Props = {
  position: 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight'
  onPress: () => void
}

export default function ExitButton({ position, onPress }: Props) {
  return (
    <View style={[styles.container, styles[position]]}>
      <Pressable onPress={onPress} style={styles.button}>
        <Feather name="x" size={24} color="#DB6B85" />
      </Pressable>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    position: 'absolute',
  },
  button: {
    borderRadius: '50%',
    borderColor: '#DB6B85',
    borderWidth: 3,
    padding: 5,
    backgroundColor: '#F7DEE4',
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
