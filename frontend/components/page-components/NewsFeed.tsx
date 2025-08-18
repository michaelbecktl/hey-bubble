import { View, StyleSheet } from 'react-native'
import UserPost from '../UserPost'

function NewsFeed() {
  const postId = [1, 2, 3, 4, 5, 6]

  return (
    <View style={styles.container}>
      {postId.map((id) => {
        return <UserPost postId={id} key={id} />
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
