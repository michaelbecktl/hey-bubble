import { Post, UserProfile } from '@/models/models'
import { View, StyleSheet } from 'react-native'
import AppText from './AppText'
import FontAwesome from '@expo/vector-icons/FontAwesome'
import Octicons from '@expo/vector-icons/Octicons'
import ProfilePhoto from './ProfilePhoto'

type Props = {
  postId: number
}

function UserPost({ postId }: Props) {
  // Replace with API call to retrieve post content data using postId //
  const post: Post = {
    postId: -1,
    userId: -123,
    content: 'This page is fire!',
    createdAt: '01082025',
    updatedAt: null,
    mediaUrl: null,
    mediaType: null,
  }

  // Replace with API call to retrieve poster data using userId //
  const userProfile: UserProfile = {
    userId: -123,
    displayName: 'Test User',
    dob: '12/06/1992',
    profilePhoto: null,
    gender: 'F',
    country: 'MY',
    nativeLanguage: 'EN',
    learningLanguage: 'JP',
  }

  // Replace with API call to retrieve like and comment count //
  const likeCount = '50'
  const commentCount = '10'

  return (
    <View style={styles.container}>
      <View>
        <View style={styles.header}>
          <View style={styles.photo}>
            <ProfilePhoto source={userProfile.profilePhoto} type="post" />
          </View>
          <View style={styles.user}>
            <AppText text={userProfile.displayName} type="poster" />
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
          <AppText text={likeCount} type="sub" />
        </View>
        <View style={styles.footerComponents}>
          <FontAwesome
            name="comment-o"
            size={16}
            color="#8a8a8aff"
            style={{ marginRight: 4 }}
          />
          <AppText text={commentCount} type="sub" />
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
