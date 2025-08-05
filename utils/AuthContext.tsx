import AsyncStorage from '@react-native-async-storage/async-storage'
import { SplashScreen, useRouter } from 'expo-router'
import { createContext, PropsWithChildren, useEffect, useState } from 'react'

SplashScreen.preventAutoHideAsync()

type AuthState = {
  isReady: boolean
  isLoggedIn: boolean
  userId: number | null
  logIn: (id: number) => void
  logOut: () => void
}

const authStorageKey = 'auth-key'

export const AuthContext = createContext<AuthState>({
  isReady: false,
  isLoggedIn: false,
  userId: null,
  logIn: (id: number) => {},
  logOut: () => {},
})

export function AuthProvider({ children }: PropsWithChildren) {
  const [isReady, setIsReady] = useState(false)
  const [isLoggedIn, setIsLoggedIn] = useState(false)
  const [userId, setUserId] = useState<number | null>(null)
  const router = useRouter()

  const storeAuthState = async (newState: { isLoggedIn: boolean }) => {
    try {
      const jsonValue = JSON.stringify(newState)
      await AsyncStorage.setItem(authStorageKey, jsonValue)
    } catch (error) {
      console.log('Error saving', error)
    }
  }

  const logIn = (id: number) => {
    setIsLoggedIn(true)
    setUserId(id)
    storeAuthState({ isLoggedIn: true })
    router.replace('/')
  }

  const logOut = () => {
    setIsLoggedIn(false)
    setUserId(null)
    storeAuthState({ isLoggedIn: false })
    router.replace('/login')
  }

  useEffect(() => {
    const getAuthFromStorage = async () => {
      try {
        const value = await AsyncStorage.getItem(authStorageKey)
        if (value !== null) {
          const auth = JSON.parse(value)
          setIsLoggedIn(auth.isLoggedIn)
        }
      } catch (error) {
        console.log('Error getting auth from storage', error)
      }
      setIsReady(true)
    }
    getAuthFromStorage()
  }, [])

  useEffect(() => {
    if (isReady) {
      SplashScreen.hideAsync()
    }
  }, [isReady])

  return (
    <AuthContext.Provider
      value={{
        isReady,
        isLoggedIn,
        userId,
        logIn,
        logOut,
      }}
    >
      {children}
    </AuthContext.Provider>
  )
}
