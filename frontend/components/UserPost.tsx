import { Post, UserProfile } from '@/models/models'
import { View } from 'react-native'
import AppText from './AppText'
import FontAwesome from '@expo/vector-icons/FontAwesome'

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

  const commentCount = '10'

  return (
    <View>
      <View>
        <View>{/* To be replaced with Profile Photo URL */}</View>
        <View>
          <View>
            <AppText text={userProfile.displayName} type="basic" />
          </View>
          <View>
            <AppText
              text={post.updatedAt ? post.updatedAt : post.createdAt}
              type="sub"
            />
          </View>
        </View>
        <View>
          <FontAwesome name="ellipsis-h" size={24} color="black" />
        </View>
      </View>
      <View>
        <AppText text={post.content} type="basic" />
      </View>
      <View>{/* To be replaced with media URL */}</View>
      <View>
        <FontAwesome name="comment-o" size={24} color="black" />
        <AppText text={commentCount} type="sub" />
      </View>
    </View>
  )
}

export default UserPost
