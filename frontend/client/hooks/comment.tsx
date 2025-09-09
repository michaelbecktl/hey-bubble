import {
  MutationFunction,
  useMutation,
  useQuery,
  useQueryClient,
} from '@tanstack/react-query'
import * as API from '../api/comment'
import { useContext } from 'react'
import { AuthContext } from '@/utils/AuthContext'

export function useComment(postId: number) {
  const authState = useContext(AuthContext)
  const token = authState.token

  const query = useQuery({
    queryKey: [postId, 'comments'],
    queryFn: () => API.GetCommentsFromPost({ token, postId }),
  })

  return { ...query }
}

export function useCommentMutation<TData = unknown, TVariables = unknown>(
  mutationFn: MutationFunction<TData, TVariables>
) {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['comment'] })
    },
  })
}
