import RegisterPopup from '@/components/auth-components/RegisterPopup'
import AppButton from '../components/AppButton'
import LoginPopup from '../components/auth-components/LoginPopup'
import { useState } from 'react'
import { StyleSheet, Text, View } from 'react-native'
import RegisterSuccessfully from '@/components/auth-components/RegisterSuccessfully'
import { Colors } from '@/constants/Colors'

export default function LoginScreen() {
  const [loginVisible, setLoginVisible] = useState<boolean>(false)
  const [registerVisible, setRegisterVisible] = useState<boolean>(false)
  const [successPopupVisible, setSuccessPopupVisible] = useState(false)

  // Closes registration, success confirmation message and sends user to login screen//
  function proceedToLogin() {
    setSuccessPopupVisible(false)
    setLoginVisible(true)
  }

  return (
    <>
      <View style={styles.container}>
        <Text style={styles.title}>Hey Bubble!</Text>
        <View style={{ marginBottom: 10 }}>
          <AppButton
            label="Login"
            onPress={() => setLoginVisible(true)} // Turns Login Popup Modal visible
            size="large"
          />
        </View>
        <AppButton
          label="Register"
          onPress={() => setRegisterVisible(true)}
          size="large"
        />
      </View>
      <LoginPopup
        modalVisible={loginVisible}
        setModalVisible={setLoginVisible}
      />
      <RegisterPopup
        modalVisible={registerVisible}
        setModalVisible={setRegisterVisible}
        setSuccessPopupVisible={setSuccessPopupVisible}
      />
      <RegisterSuccessfully
        modalVisible={successPopupVisible}
        setModalVisible={setSuccessPopupVisible}
        proceedToLogin={proceedToLogin}
      />
    </>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: Colors.themeBackground,
  },
  title: {
    fontSize: 48,
    fontWeight: 'bold',
    color: Colors.text,
    marginBottom: 24,
  },
  textField: {
    width: 250,
    height: 40,
    backgroundColor: Colors.textfield,
    borderRadius: 5,
    marginTop: 5,
    marginBottom: 20,
    textAlign: 'center',
  },
})
