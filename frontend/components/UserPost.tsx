import { Post } from '@/models/models'
import { router } from 'expo-router'
import { View, StyleSheet, Pressable } from 'react-native'
import AppText from './AppText'
import FontAwesome from '@expo/vector-icons/FontAwesome'
import ProfilePhoto from './ProfilePhoto'
import { RelativeTime } from './RelativeTime'
import LikeComponent from './LikeComponent'
import { Colors } from '@/constants/Colors'

type Props = {
  post: Post
  commentsVisible: boolean
}

function UserPost({ post, commentsVisible }: Props) {
  function navigateToPost(postId: number) {
    router.push({
      pathname: '/(protected)/pages/postfocused',
      params: { postId: postId },
    })
  }

  return (
    <View style={styles.container}>
      <View>
        <View style={styles.header}>
          <View style={styles.photo}>
            <ProfilePhoto source={null} type="post" />
          </View>
          <View style={styles.user}>
            <AppText text={post.displayName} type="poster" />
            <RelativeTime
              date={post.updatedAt ? post.updatedAt : post.createdAt}
            />
          </View>
          <View style={styles.options}>
            <FontAwesome name="ellipsis-h" size={24} color="#8a8a8aff" />
          </View>
        </View>
      </View>
      <View style={styles.body}>
        <AppText text={post.content} type="basic" />
      </View>
      <View>{/* To be replaced with media URL */}</View>
      <View style={styles.footer}>
        <View style={styles.footerComponents}>
          <LikeComponent type="post" content={post} />
        </View>
        <Pressable
          onPress={
            commentsVisible ? () => {} : () => navigateToPost(post.postId)
          }
        >
          <View style={styles.footerComponents}>
            <FontAwesome
              name="comment-o"
              size={16}
              color="#8a8a8aff"
              style={{ marginRight: 4 }}
            />
            <AppText
              text={post.commentCount ? post.commentCount.toString() : '0'}
              type="sub"
            />
          </View>
        </Pressable>
      </View>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    backgroundColor: Colors.background,
    marginBottom: 1,
    padding: 10,
  },
  header: {
    flexDirection: 'row',
  },
  photo: { marginRight: 5, alignItems: 'center', justifyContent: 'center' },
  user: {
    flexGrow: 5,
  },
  options: {},
  body: {
    marginVertical: 8,
  },
  footer: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  footerComponents: {
    flexDirection: 'row',
    marginRight: 10,
  },
})

export default UserPost
