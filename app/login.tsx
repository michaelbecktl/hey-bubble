import AppButton from '@/components/AppButton'
import { AuthContext } from '@/utils/AuthContext'
import { useContext } from 'react'
import { StyleSheet, Text, View } from 'react-native'

export default function LoginScreen() {
  const authContext = useContext(AuthContext)

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Hey Bubble!</Text>
      <AppButton label="Login" onPress={authContext.logIn} size="large" />
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#F1EBFA',
  },
  title: {
    fontSize: 48,
    fontWeight: 'bold',
    color: '#0D0628',
    marginBottom: 24,
  },
})
