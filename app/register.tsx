import AppButton from '@/components/AppButton'
import { AuthContext } from '@/utils/AuthContext'
import { useContext, useState } from 'react'
import { StyleSheet, Text, TextInput, View } from 'react-native'

export default function LoginScreen() {
  const authContext = useContext(AuthContext)
  const [username, onChangeUsername] = useState('')
  const [email, onChangeEmail] = useState('')
  const [password, onChangePassword] = useState('')

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Hey Bubble!</Text>
      <Text>Username</Text>
      <TextInput
        value={username}
        onChangeText={onChangeUsername}
        style={styles.textField}
      />
      <Text>Email</Text>
      <TextInput
        value={email}
        onChangeText={onChangeEmail}
        style={styles.textField}
      />
      <Text>Password</Text>
      <TextInput
        value={password}
        onChangeText={onChangePassword}
        style={styles.textField}
      />

      <AppButton label="Register" onPress={authContext.logIn} size="large" />
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
  textField: {
    width: 250,
    height: 40,
    backgroundColor: '#fff',
    borderRadius: 5,
    marginTop: 5,
    marginBottom: 20,
    textAlign: 'center',
  },
})
