import { View, StyleSheet } from 'react-native'
import UserPost from '../UserPost'
import { usePost } from '@/client/hooks/post'
import { Post } from '@/models/models'

function NewsFeed() {
  const postQuery = usePost()

  if (postQuery.isPending) return

  const posts: Post[] = postQuery.data

  return (
    <View style={styles.container}>
      {posts.map((post) => {
        return <UserPost post={post} key={post.postId} />
      })}
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    backgroundColor: '#F1EBFA',
  },
})

export default NewsFeed
