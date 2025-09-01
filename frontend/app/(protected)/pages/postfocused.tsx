import { usePost } from '@/client/hooks/post'
import UserPost from '@/components/UserPost'
import { Post } from '@/models/models'
import { useLocalSearchParams } from 'expo-router'

function PostFocused() {
  const queryPosts = usePost()
  const params = useLocalSearchParams()
  const postId = Number(params.postId)

  if (queryPosts.isPending) return

  const posts = queryPosts.data
  const selectedPost = posts.find(
    (post: Post) => post.postId === Number(postId)
  )

  return (
    <>
      <UserPost post={selectedPost} />
    </>
  )
}

export default PostFocused
