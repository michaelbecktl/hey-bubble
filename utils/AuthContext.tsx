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

  const storeAuthState = async (newState: {
    isLoggedIn: boolean
    userId: number | null
  }) => {
    try {
      const jsonValue = JSON.stringify(newState)
      await AsyncStorage.setItem(authStorageKey, jsonValue)
    } catch (error) {
      console.log('Error saving', error)
    }
  }

  // Takes user ID from API request after successful login to store for retrieving user relevant data post login
  const logIn = (id: number) => {
    setIsLoggedIn(true)
    setUserId(id)

    // Saves login history to remember use if app has been closed and reopened
    storeAuthState({ isLoggedIn: true, userId: userId })
    router.replace('/')
  }

  // Removes user ID from context and takes the user back to login page
  const logOut = () => {
    setIsLoggedIn(false)
    setUserId(null)

    // Saves logout history to remember use if app has been closed and reopened
    storeAuthState({ isLoggedIn: false, userId: userId })
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
        userId,
        logIn,
        logOut,
      }}
    >
      {children}
    </AuthContext.Provider>
  )
}
