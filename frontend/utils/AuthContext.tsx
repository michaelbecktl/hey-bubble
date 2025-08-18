import AsyncStorage from '@react-native-async-storage/async-storage'
import { SplashScreen, useRouter } from 'expo-router'
import { createContext, PropsWithChildren, useEffect, useState } from 'react'

SplashScreen.preventAutoHideAsync()

type AuthState = {
  isReady: boolean
  isLoggedIn: boolean
  token: string | null
  logIn: (t: string) => void
  logOut: () => void
}

const authStorageKey = 'auth-key'

export const AuthContext = createContext<AuthState>({
  isReady: false,
  isLoggedIn: false,
  token: null,
  logIn: (t: string) => {},
  logOut: () => {},
})

export function AuthProvider({ children }: PropsWithChildren) {
  const [isReady, setIsReady] = useState(false)
  const [isLoggedIn, setIsLoggedIn] = useState(false)
  const [token, setToken] = useState<string | null>(null)
  const router = useRouter()

  const storeAuthState = async (newState: {
    isLoggedIn: boolean
    token: string | null
  }) => {
    try {
      const jsonValue = JSON.stringify(newState)
      await AsyncStorage.setItem(authStorageKey, jsonValue)
    } catch (error) {
      console.log('Error saving', error)
    }
  }

  // Takes user ID from API request after successful login to store for retrieving user relevant data post login
  const logIn = (t: string) => {
    setIsLoggedIn(true)
    setToken(t)

    // Saves login history to remember use if app has been closed and reopened
    storeAuthState({ isLoggedIn: true, token: token })
    router.replace('/')
  }

  // Removes user ID from context and takes the user back to login page
  const logOut = () => {
    setIsLoggedIn(false)
    setToken(null)

    // Saves logout history to remember use if app has been closed and reopened
    storeAuthState({ isLoggedIn: false, token: token })
    router.replace('/login')
  }

  useEffect(() => {
    // Reattempt to check and verify if user is logged in from auth history
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
        token,
        logIn,
        logOut,
      }}
    >
      {children}
    </AuthContext.Provider>
  )
}
