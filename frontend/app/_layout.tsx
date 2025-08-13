import { QueryClient, QueryClientProvider } from '@tanstack/react-query'
import { AuthProvider } from '../utils/AuthContext'
import { Stack } from 'expo-router'
import { StatusBar } from 'expo-status-bar'

export default function RootLayout() {
  const queryClient = new QueryClient()

  return (
    <AuthProvider>
      <QueryClientProvider client={queryClient}>
        <StatusBar style="auto" />
        <Stack>
          <Stack.Screen
            name="(protected)"
            options={{ headerShown: false, animation: 'none' }}
          />
          <Stack.Screen
            name="login"
            options={{ headerShown: false, animation: 'none' }}
          />
          <Stack.Screen
            name="register"
            options={{ headerShown: false, animation: 'none' }}
          />
        </Stack>
      </QueryClientProvider>
    </AuthProvider>
  )
}
