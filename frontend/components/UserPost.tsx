import { Post } from '@/models/models'
import { View, StyleSheet } from 'react-native'
import AppText from './AppText'
import FontAwesome from '@expo/vector-icons/FontAwesome'
import Octicons from '@expo/vector-icons/Octicons'
import ProfilePhoto from './ProfilePhoto'

type Props = {
  post: Post
}

function UserPost({ post }: Props) {
  return (
    <View style={styles.container}>
      <View>
        <View style={styles.header}>
          <View style={styles.photo}>
            <ProfilePhoto source={null} type="post" />
          </View>
          <View style={styles.user}>
            <AppText text={post.displayName} type="poster" />
            <AppText
              text={post.updatedAt ? post.updatedAt : post.createdAt}
              type="sub"
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
          <Octicons
            name="thumbsup"
            size={14}
            color="#8a8a8aff"
            style={{ marginRight: 4 }}
          />
          <AppText
            text={post.likeCount ? post.likeCount.toString() : '0'}
            type="sub"
          />
        </View>
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
      </View>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    backgroundColor: '#fcf7fa',
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
