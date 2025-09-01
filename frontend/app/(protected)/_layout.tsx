import { AuthContext } from '@/utils/AuthContext'
import { Redirect, Stack } from 'expo-router'
import { useContext } from 'react'
import PostFocused from './pages/postfocused'

export default function ProtectedLayout() {
  const authState = useContext(AuthContext)

  if (!authState.isReady) {
    return null
  }

  if (!authState.isLoggedIn || !authState.token) {
    return <Redirect href="/login" />
  }

  return (
    <Stack>
      <Stack.Screen name="(tabs)" options={{ headerShown: false }} />
      <Stack.Screen
        name="pages/postfocused"
        options={{
          title: 'Post',
          presentation: 'card',
          headerStyle: {
            backgroundColor: '#F1EBFA',
          },
          headerTintColor: '#DA627D',
        }}
      />
      <Stack.Screen name="+not-found" />
    </Stack>
  )
}
