import { useQuery } from '@tanstack/react-query'
import * as API from '../api/user'
import { useContext } from 'react'
import { AuthContext } from '@/utils/AuthContext'

export function useUser() {
  const authState = useContext(AuthContext)
  const token = authState.token

  const query = useQuery({
    queryKey: ['currentUserProfile'],
    queryFn: () => API.GetCurrentUserProfile({ token }),
  })

  return {
    ...query,
    useSelectedUserProfile: (userId: number) =>
      useUserProfile({ token, userId }),
  }
}

export function useUserProfile({
  token,
  userId,
}: {
  token: string | null
  userId: number
}) {
  return useQuery({
    queryKey: [userId, 'userProfile'],
    queryFn: () => API.GetUserProfileById({ token, userId }),
  })
}
