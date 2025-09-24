import {
  MutationFunction,
  useMutation,
  useQueryClient,
} from '@tanstack/react-query'
import * as API from '../api/like'
import { useContext } from 'react'
import { AuthContext } from '@/utils/AuthContext'

interface LikeRequest {
  token: string | null
  contentId: number
}

export function useLike(contentId: number) {
  const authState = useContext(AuthContext)
  const token = authState.token
  const request = { token: token, contentId: contentId }

  return {
    addLikeToPost: useAddLikeToPost(request),
    addLikeToComment: useAddLikeToComment(request),
    removeLikeFromPost: useRemoveLikeFromPost(request),
    removeLikeFromComment: useRemoveLikeFromComment(request),
  }
}

export function useLikeMutation<TData = unknown, TVariables = unknown>(
  mutationFn: MutationFunction<TData, TVariables>,
  key: string
) {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: [key] })
    },
  })
}

export function useAddLikeToPost(request: LikeRequest) {
  return useLikeMutation(() => API.addLikeToPost(request), 'posts')
}

export function useRemoveLikeFromPost(request: LikeRequest) {
  return useLikeMutation(() => API.removeLikeFromPost(request), 'posts')
}

export function useAddLikeToComment(request: LikeRequest) {
  return useLikeMutation(() => API.addLikeToComment(request), 'comments')
}

export function useRemoveLikeFromComment(request: LikeRequest) {
  return useLikeMutation(() => API.removeLikeFromComment(request), 'comments')
}
