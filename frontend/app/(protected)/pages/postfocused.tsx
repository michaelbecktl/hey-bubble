import { useComment } from '@/client/hooks/comment'
import { usePost } from '@/client/hooks/post'
import CreateComment from '@/components/CreateComment'
import UserComment from '@/components/UserComment'
import UserPost from '@/components/UserPost'
import { Post, PostComment } from '@/models/models'
import { useLocalSearchParams } from 'expo-router'
import { ScrollView, View } from 'react-native'
import { SafeAreaView } from 'react-native-safe-area-context'

function PostFocused() {
  const params = useLocalSearchParams()
  const postId = Number(params.postId)

  const queryPosts = usePost()
  const queryComments = useComment(postId)

  if (queryPosts.isPending || queryComments.isPending) return

  const posts = queryPosts.data
  const selectedPost = posts.find(
    (post: Post) => post.postId === Number(postId)
  )

  const comments: PostComment[] = queryComments.data

  return (
    <>
      <ScrollView>
        <UserPost post={selectedPost} commentsVisible={true} />
        {comments.map((comment: PostComment) => (
          <UserComment comment={comment} key={comment.commentId} />
        ))}
      </ScrollView>
      <CreateComment autoFocus={false} postId={postId} />
    </>
  )
}

export default PostFocused
