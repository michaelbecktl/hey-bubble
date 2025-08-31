import {
  MutationFunction,
  useMutation,
  useQuery,
  useQueryClient,
} from '@tanstack/react-query'
import * as API from '../api/post'
import { useContext } from 'react'
import { AuthContext } from '@/utils/AuthContext'

export function usePost() {
  const authState = useContext(AuthContext)

  const query = useQuery({
    queryKey: ['publicPosts'],
    queryFn: () => API.GetPublicPosts({ token: authState.token }),
  })

  return { ...query }
}

export function usePostMutation<TData = unknown, TVariables = unknown>(
  mutationFn: MutationFunction<TData, TVariables>
) {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['publicPosts'] })
    },
  })
}
