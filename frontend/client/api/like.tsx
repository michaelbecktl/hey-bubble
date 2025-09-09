import request from 'superagent'

const rootURL = new URL(`http://192.168.50.59:5218/api/v1/like`)

interface LikeRequest {
  token: string | null
  contentId: number
}

export async function addLikeToPost({ token, contentId }: LikeRequest) {
  try {
    if (!token) throw new Error('Unauthorized')
    if (!contentId) throw new Error('Unable to find post')

    const response = await request
      .post(`${rootURL}/post/${contentId}`)
      .set('Authorization', `Bearer ${token}`)

    return response.body
  } catch (error: any) {
    throw error
  }
}

export async function addLikeToComment({ token, contentId }: LikeRequest) {
  try {
    if (!token) throw new Error('Unauthorized')
    if (!contentId) throw new Error('Unable to find comment')

    const response = await request
      .post(`${rootURL}/comment/${contentId}`)
      .set('Authorization', `Bearer ${token}`)

    return response.body
  } catch (error: any) {
    throw error
  }
}

export async function removeLikeFromPost({ token, contentId }: LikeRequest) {
  try {
    if (!token) throw new Error('Unauthorized')
    if (!contentId) throw new Error('Unable to find post')

    const response = await request
      .delete(`${rootURL}/post/${contentId}`)
      .set('Authorization', `Bearer ${token}`)

    return response.body
  } catch (error: any) {
    throw error
  }
}

export async function removeLikeFromComment({ token, contentId }: LikeRequest) {
  try {
    if (!token) throw new Error('Unauthorized')
    if (!contentId) throw new Error('Unable to find comment')

    const response = await request
      .delete(`${rootURL}/comment/${contentId}`)
      .set('Authorization', `Bearer ${token}`)

    return response.body
  } catch (error: any) {
    throw error
  }
}
