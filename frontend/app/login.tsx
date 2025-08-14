import RegisterPopup from '@/components/RegisterPopup'
import AppButton from '../components/AppButton'
import LoginPopup from '../components/LoginPopup'
import { AuthContext } from '../utils/AuthContext'
import { useRouter } from 'expo-router'
import { useContext, useState } from 'react'
import { StyleSheet, Text, View } from 'react-native'

export default function LoginScreen() {
  const [loginVisible, setLoginVisible] = useState<boolean>(false)
  const [registerVisible, setRegisterVisible] = useState<boolean>(false)

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
      />
    </>
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
