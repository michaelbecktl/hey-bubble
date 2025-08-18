export interface UserCredentials {
  username: string
  password: string
  email?: string
}

export interface User extends UserCredentials {
  id: number
}

export interface UserProfile {
  userId: number
  displayName: string
  dob: string
  profilePhoto?: string | null
  gender: string
  country: string
  nativeLanguage: string
  learningLanguage: string
}
export interface Post {
  postId: number
  userId: number
  content: string
  createdAt: string
  updatedAt?: string | null
  mediaUrl?: string | null
  mediaType?: string | null
}
