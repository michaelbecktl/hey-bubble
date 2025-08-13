import {
  MutationFunction,
  useMutation,
  useQueryClient,
} from '@tanstack/react-query'
import * as API from '../api/user'

export function useAuth() {
  return {
    loginUser: useAttemptLogin(),
    registerUser: useRegisterUser(),
  }
}

export function useAuthMutation<TData = unknown, TVariables = unknown>(
  mutationFn: MutationFunction<TData, TVariables>
) {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['auth'] })
    },
  })
}

export function useAttemptLogin() {
  return useAuthMutation(API.LoginUser)
}

export function useRegisterUser() {
  return useAuthMutation(API.RegisterUser)
}
