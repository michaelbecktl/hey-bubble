import { useAuth } from '../client/hooks/auth'
import AppButton from '../components/AppButton'
import { UserCredentials } from '../models/models'
import { AuthContext } from '../utils/AuthContext'
import { useContext, useEffect, useState } from 'react'
import { Modal, StyleSheet, Text, TextInput, View } from 'react-native'

type Props = {
  modalVisible: boolean
  setModalVisible: (modalVisible: boolean) => void
}

export default function LoginPopup({ modalVisible, setModalVisible }: Props) {
  const auth = useAuth()
  const authContext = useContext(AuthContext)
  const [username, onChangeUsername] = useState('')
  const [email, onChangeEmail] = useState('')
  const [password, onChangePassword] = useState('')
  const [confirmPassword, onChangeConfirmPassword] = useState('')
  const [errorMessage, setErrorMessage] = useState('')

  function handlePassword(
    value: string,
    field: 'password' | 'confirmPassword'
  ) {
    if (field === 'password') onChangePassword(value)
    if (field === 'confirmPassword') onChangeConfirmPassword(value)
  }

  async function onPressRegister() {
    try {
      const userDetails: UserCredentials = {
        username: username,
        email: email,
        password: password,
      }

      const id = await auth.registerUser.mutateAsync(userDetails)

      setModalVisible(!modalVisible)
      alert("Yay! You've successfully registered, please try logging in!")
      return id
    } catch (error: any) {
      setErrorMessage(error?.response?.body.message)
    }
  }

  return (
    <Modal
      animationType="fade"
      transparent={true}
      visible={modalVisible}
      onRequestClose={() => setModalVisible(!modalVisible)}
    >
      <View style={styles.container}>
        <View style={styles.modalView}>
          <Text style={styles.textFieldTitle}>Username</Text>
          <TextInput
            value={username}
            onChangeText={onChangeUsername}
            style={styles.textField}
          />
          <Text style={styles.textFieldTitle}>Email Address</Text>
          <TextInput
            value={email}
            onChangeText={onChangeEmail}
            style={styles.textField}
          />
          <Text style={styles.textFieldTitle}>Password</Text>
          <TextInput
            value={password}
            onChangeText={(value) => handlePassword(value, 'password')}
            style={styles.textField}
            secureTextEntry={true}
          />
          <Text style={styles.textFieldTitle}>Confirm Password</Text>
          <TextInput
            value={confirmPassword}
            onChangeText={(value) => handlePassword(value, 'confirmPassword')}
            style={styles.textField}
            secureTextEntry={true}
          />
          <View>
            <Text style={styles.error}>
              {password === confirmPassword ? '' : 'Passwords do not match'}
            </Text>
            <Text style={styles.error}>{errorMessage}</Text>
          </View>
          <View style={{ marginBottom: 10 }}>
            <AppButton
              label="Register"
              onPress={onPressRegister}
              size="large"
            />
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
