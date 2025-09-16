import {
  MutationFunction,
  useMutation,
  useQuery,
  useQueryClient,
} from '@tanstack/react-query'
import * as API from '../api/post'
import { useContext } from 'react'
import { AuthContext } from '@/utils/AuthContext'
import { PostDTO } from '@/models/models'

export function usePost() {
  const authState = useContext(AuthContext)
  const token = authState.token

  const query = useQuery({
    queryKey: ['publicPosts'],
    queryFn: () => API.GetPublicPosts({ token: authState.token }),
  })

  return {
    ...query,
    useCreatePost: (content: PostDTO) => useCreatePost({ token, content }),
  }
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

export function useCreatePost({
  token,
  content,
}: {
  token: string | null
  content: PostDTO
}) {
  return usePostMutation(() => API.CreatePosts({ token, content }))
}
