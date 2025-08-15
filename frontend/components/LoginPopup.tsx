import { useAuth } from '../client/hooks/auth'
import AppButton from '../components/AppButton'
import { UserCredentials } from '../models/models'
import { AuthContext } from '../utils/AuthContext'
import { useContext, useState } from 'react'
import { Modal, StyleSheet, Text, TextInput, View } from 'react-native'
import ExitButton from './ExitButton'

type Props = {
  modalVisible: boolean
  setModalVisible: (modalVisible: boolean) => void
}

export default function LoginPopup({ modalVisible, setModalVisible }: Props) {
  const auth = useAuth()
  const authContext = useContext(AuthContext)
  const [username, onChangeUsername] = useState('')
  const [password, onChangePassword] = useState('')
  const [errorMessage, setErrorMessage] = useState('')

  async function onPressLogin() {
    try {
      const loginDetails: UserCredentials = {
        username: username,
        password: password,
      }
      const id = await auth.loginUser.mutateAsync(loginDetails)

      // Login should return Id after successful login
      setModalVisible(!modalVisible)
      authContext.logIn(id)
    } catch (error: any) {
      const loginError = error?.response?.body.message ?? 'Failed to login'
      setErrorMessage(loginError)
      alert(loginError)
    }
  }

  return (
    <Modal
      animationType="slide"
      transparent={true}
      visible={modalVisible}
      onRequestClose={() => setModalVisible(!modalVisible)}
    >
      <View style={styles.container}>
        <View>
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
          <ExitButton
            position="topRight"
            onPress={() => setModalVisible(!modalVisible)}
          />
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
    boxShadow: '0px 2px 4px rgba(0, 0, 0, 0.25)',
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
