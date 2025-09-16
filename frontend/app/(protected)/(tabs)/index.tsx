import { useUser } from '@/client/hooks/user'
import NewsFeed from '@/components/page-components/NewsFeed'
import { View, StyleSheet } from 'react-native'
import BadgeButton from '@/components/BadgeButton'
import { router } from 'expo-router'

export default function Home() {
  const currentUser = useUser()

  if (currentUser.isPending) return

  return (
    <>
      <View style={styles.container}>
        <NewsFeed />
        <BadgeButton
          position="bottomRight"
          type="plus"
          margin={15}
          size={36}
          onPress={() => {
            router.push({ pathname: '/(protected)/pages/createpost' })
          }}
        />
      </View>
    </>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  postButton: {},
})
