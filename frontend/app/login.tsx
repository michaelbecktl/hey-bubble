import AppButton from '../components/AppButton'
import LoginPopup from '../components/LoginPopup'
import { AuthContext } from '../utils/AuthContext'
import { useRouter } from 'expo-router'
import { useContext, useState } from 'react'
import { StyleSheet, Text, View } from 'react-native'

export default function LoginScreen() {
  const router = useRouter()
  const authContext = useContext(AuthContext)

  const [loginVisible, setLoginVisible] = useState<boolean>(false)

  const redirectToRegister = () => {
    router.push('/register')
  }

  // To be used for graying out main menu while popup is active
  // function isPopupVisible() {
  //   if (loginVisible) return true
  //   else return false
  // }

  return (
    <>
      <View style={styles.container}>
        <Text style={styles.title}>Hey Bubble!</Text>
        <View style={{ marginBottom: 10 }}>
          <AppButton
            label="Login"
            onPress={() => setLoginVisible(true)} // Replace with actual login logic
            size="large"
          />
        </View>
        <AppButton label="Register" onPress={redirectToRegister} size="large" />
      </View>
      <LoginPopup
        loginVisible={loginVisible}
        setModalVisible={setLoginVisible}
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
