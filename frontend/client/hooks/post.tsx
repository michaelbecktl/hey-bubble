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
    queryKey: ['posts'],
    queryFn: () => API.GetPublicPosts({ token: token }),
  })

  return {
    ...query,
    useCreatePost: useCreatePost({ token }),
  }
}

export function usePostMutation<TData = unknown, TVariables = unknown>(
  mutationFn: MutationFunction<TData, TVariables>
) {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['posts'] })
    },
  })
}

export function useCreatePost({ token }: { token: string | null }) {
  return usePostMutation((content: PostDTO) =>
    API.CreatePosts({ token, content })
  )
}
