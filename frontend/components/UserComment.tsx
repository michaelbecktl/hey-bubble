import { PostComment } from '@/models/models'
import { View, StyleSheet } from 'react-native'
import AppText from './AppText'
import { FontAwesome, Octicons } from '@expo/vector-icons'
import ProfilePhoto from './ProfilePhoto'
import { RelativeTime } from './RelativeTime'
import LikeComponent from './LikeComponent'

type Props = {
  comment: PostComment
}

function UserComment({ comment }: Props) {
  return (
    <View style={styles.container}>
      <View>
        <View style={styles.header}>
          <View style={styles.photo}>
            <ProfilePhoto source={null} type="post" />
          </View>
          <View style={styles.body}>
            <View style={styles.chatBubble}>
              <AppText text={comment.displayName} type="poster" />
              <View>
                <AppText text={comment.content} type="basic" />
              </View>
              <View>{/* To be replaced with media URL */}</View>
            </View>
            <View style={styles.footer}>
              <View style={styles.footerComponents}>
                <LikeComponent type="comment" content={comment} />
              </View>
              <View style={styles.footerComponents}>
                <RelativeTime
                  date={
                    comment.updatedAt ? comment.updatedAt : comment.createdAt
                  }
                />
              </View>
            </View>
          </View>
          <View style={styles.options}>
            <FontAwesome name="ellipsis-h" size={24} color="#8a8a8aff" />
          </View>
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
  photo: { marginRight: 5, alignItems: 'center' },
  body: {
    flexGrow: 5,
  },
  chatBubble: {
    paddingHorizontal: 10,
    paddingVertical: 5,
    backgroundColor: '#f1ebfa',
    marginRight: 15,
    borderRadius: 15,
    alignSelf: 'flex-start',
    flexShrink: 1,
  },
  options: {},
  footer: {
    flexDirection: 'row',
    alignItems: 'center',
    marginTop: 10,
  },
  footerComponents: {
    flexDirection: 'row',
    marginRight: 10,
  },
})

// <View>
//   <View>UserPfp</View>
//   <View>
//     <View>
//       <Text>Commenter Name</Text>
//     </View>
//     <View>
//       <Text>Comment</Text>
//     </View>
//     <View>
//       <Text>Date</Text>Like Button<Text>Like Counter</Text>
//     </View>
//   </View>
// </View>

export default UserComment
