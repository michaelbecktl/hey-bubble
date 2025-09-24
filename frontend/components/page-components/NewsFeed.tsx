import { View, StyleSheet, ScrollView } from 'react-native'
import UserPost from '../UserPost'
import { usePost } from '@/client/hooks/post'
import { Post } from '@/models/models'
import { Colors } from '@/constants/Colors'

function NewsFeed() {
  const postQuery = usePost()

  if (postQuery.isPending) return

  const posts: Post[] = postQuery.data

  return (
    <ScrollView>
      <View style={styles.container}>
        {posts.map((post) => {
          return (
            <UserPost post={post} commentsVisible={false} key={post.postId} />
          )
        })}
      </View>
    </ScrollView>
  )
}

const styles = StyleSheet.create({
  container: {
    backgroundColor: Colors.themeBackground,
  },
})

export default NewsFeed
