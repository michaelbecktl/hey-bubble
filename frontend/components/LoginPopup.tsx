import { useAuth } from '../client/hooks/auth'
import AppButton from '../components/AppButton'
import { UserCredentials } from '../models/models'
import { AuthContext } from '../utils/AuthContext'
import { useContext, useState } from 'react'
import { Modal, StyleSheet, Text, TextInput, View } from 'react-native'

type Props = {
  loginVisible: boolean
  setModalVisible: (loginVisible: boolean) => void
}

export default function LoginPopup({ loginVisible, setModalVisible }: Props) {
  const auth = useAuth()
  const authContext = useContext(AuthContext)
  const [username, onChangeUsername] = useState('')
  const [password, onChangePassword] = useState('')
  const [errorMessage, setErrorMessage] = useState('')

  async function onPressLogin() {
    // Login Request Function
    async function attemptLogin() {
      const loginDetails: UserCredentials = {
        username: username,
        password: password,
      }
      return await auth.loginUser.mutateAsync(loginDetails)
    }

    // Login should return Id after successful login
    const response = await attemptLogin()

    if (!response.id) {
      alert(response.message)
      setErrorMessage(response.message)
    } else {
      // Should close login popup screen and renavigate to main page
      setModalVisible(!loginVisible)
      authContext.logIn(response.id)
    }
  }

  return (
    <Modal
      animationType="fade"
      transparent={true}
      visible={loginVisible}
      onRequestClose={() => setModalVisible(!loginVisible)}
    >
      <View style={styles.container}>
        <View style={styles.modalView}>
          <Text style={styles.textFieldTitle}>Username or email address</Text>
          <TextInput
            value={username}
            onChangeText={onChangeUsername}
            style={styles.textField}
          />
          <Text style={styles.textFieldTitle}>Password</Text>
          <TextInput
            value={password}
            onChangeText={onChangePassword}
            style={styles.textField}
            secureTextEntry={true}
          />
          <View>
            <Text style={styles.error}>{errorMessage}</Text>
          </View>
          <View style={{ marginBottom: 10 }}>
            <AppButton label="Login" onPress={onPressLogin} size="large" />
          </View>
        </View>
      </View>
    </Modal>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    marginTop: 22,
  },
  modalView: {
    margin: 20,
    backgroundColor: 'white',
    borderRadius: 20,
    padding: 35,
    alignItems: 'center',
    shadowColor: '#000',
    shadowOffset: {
      width: 0,
      height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 4,
    elevation: 5,
  },
  textFieldTitle: {
    alignSelf: 'flex-start',
    marginLeft: 5,
    fontWeight: 'bold',
  },
  textField: {
    width: 250,
    height: 40,
    backgroundColor: '#f5f5f5ff',
    borderRadius: 5,
    marginTop: 5,
    marginBottom: 20,
    textAlign: 'center',
  },
  error: {
    margin: 5,
    color: '#ff0000ff',
  },
})
