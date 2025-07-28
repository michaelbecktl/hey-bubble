import AppButton from '@/components/AppButton'
import { AuthContext } from '@/utils/AuthContext'
import { useContext } from 'react'
import { StyleSheet, View } from 'react-native'

export default function SettingsPage() {
  const authContext = useContext(AuthContext)

  return (
    <View style={styles.container}>
      <AppButton label="Logout" onPress={authContext.logOut} />
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  text: {
    color: '#0D0628',
  },
})
