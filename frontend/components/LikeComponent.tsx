import { Post, PostComment } from '@/models/models'
import { Octicons } from '@expo/vector-icons'
import AppText from './AppText'
import { useCallback, useMemo, useState } from 'react'
import { Pressable } from 'react-native'
import { useLike } from '@/client/hooks/like'

type Props = {
  type: 'post' | 'comment'
  content: Post | PostComment
}

function LikeComponent({ type, content }: Props) {
  const [likeCount, setLikeCount] = useState(
    content.likeCount ? content.likeCount : 0
  )
  const [isLikedByUser, setIsLikedByUser] = useState(content.isLikedByUser)

  const contentId =
    type === 'post'
      ? (content as Post).postId
      : (content as PostComment).commentId

  const like = useLike(contentId)

  const addLike = useCallback(
    async (id: number) => {
      if (type === 'post') return await like.addLikeToPost.mutateAsync(id)
      if (type === 'comment') return await like.addLikeToComment.mutateAsync(id)
    },
    [type, like]
  )

  const removeLike = useCallback(
    async (id: number) => {
      if (type === 'post') return await like.removeLikeFromPost.mutateAsync(id)
      if (type === 'comment')
        return await like.removeLikeFromComment.mutateAsync(id)
    },
    [type, like]
  )

  function debounce(fn: (id: number) => void, delay: number) {
    let timeout: number
    return function (id: number) {
      clearTimeout(timeout)
      timeout = setTimeout(() => fn(id), delay)
    }
  }

  const debouncedAddLike = useMemo(() => debounce(addLike, 500), [addLike])
  const debouncedRemoveLike = useMemo(
    () => debounce(removeLike, 500),
    [removeLike]
  )

  async function handleLike(id: number) {
    if (isLikedByUser) {
      setIsLikedByUser(false)
      setLikeCount(likeCount - 1)
      debouncedRemoveLike(id)
    } else if (!isLikedByUser) {
      setIsLikedByUser(true)
      setLikeCount(likeCount + 1)
      debouncedAddLike(id)
    }
  }

  return (
    <>
      <Pressable onPress={() => handleLike(contentId)}>
        <Octicons
          name="thumbsup"
          size={14}
          color={isLikedByUser ? '#da627d' : '#8a8a8aff'}
          style={{ marginRight: 4 }}
        />
      </Pressable>
      <AppText text={likeCount.toString()} type="sub" />
    </>
  )
}

export default LikeComponent
