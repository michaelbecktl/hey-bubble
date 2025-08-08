import AppButton from '@/components/AppButton'
import { AuthContext } from '@/utils/AuthContext'
import { useContext, useState } from 'react'
import { Modal, StyleSheet, Text, TextInput, View } from 'react-native'

type Props = {
  loginVisible: boolean
  setModalVisible: (loginVisible: boolean) => void
}

export default function LoginPopup({ loginVisible, setModalVisible }: Props) {
  const authContext = useContext(AuthContext)
  const [username, onChangeUsername] = useState('')
  const [password, onChangePassword] = useState('')

  return (
    <Modal
      animationType="fade"
      transparent={true}
      visible={loginVisible}
      onRequestClose={() => setModalVisible(!loginVisible)}
    >
      <View style={styles.container}>
        <View style={styles.modalView}>
          <Text style={styles.text}>Username</Text>
          <TextInput
            value={username}
            onChangeText={onChangeUsername}
            style={styles.textField}
          />
          <Text style={styles.text}>Password</Text>
          <TextInput
            value={password}
            onChangeText={onChangePassword}
            style={styles.textField}
          />
          <View style={{ marginBottom: 10 }}>
            <AppButton
              label="Login"
              onPress={() => setModalVisible(false)} // Replace with actual login logic
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
  text: {
    alignSelf: 'flex-start',
    marginLeft: 5,
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
})
