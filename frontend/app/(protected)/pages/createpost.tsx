import { usePost } from '@/client/hooks/post'
import { UserProfile } from '@/models/models'
import { useState } from 'react'
import { TextInput } from 'react-native'

type Props = {
  user: UserProfile
}

function CreatePost({ user }: Props) {
  const queryPosts = usePost()
  const [text, onChangeText] = useState('')

  if (queryPosts.isPending) return

  return (
    <>
      <TextInput value={text} onChangeText={onChangeText} />
    </>
  )
}

export default CreatePost
