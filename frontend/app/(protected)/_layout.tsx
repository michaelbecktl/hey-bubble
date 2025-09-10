import { AuthContext } from '@/utils/AuthContext'
import { Redirect, Stack } from 'expo-router'
import { useContext } from 'react'
import { Colors } from '@/constants/Colors'

export default function ProtectedLayout() {
  const authState = useContext(AuthContext)

  if (!authState.isReady) {
    return null
  }

  if (!authState.isLoggedIn || !authState.token) {
    return <Redirect href="/login" />
  }

  return (
    <Stack screenOptions={{ headerBackButtonDisplayMode: 'minimal' }}>
      <Stack.Screen name="(tabs)" options={{ headerShown: false }} />
      <Stack.Screen
        name="pages/postfocused"
        options={{
          title: 'Post',
          presentation: 'card',
          headerStyle: {
            backgroundColor: Colors.themeBackground,
          },
          headerTintColor: Colors.secondary,
        }}
      />
      <Stack.Screen name="+not-found" />
    </Stack>
  )
}
