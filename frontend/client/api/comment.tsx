import request from 'superagent'

const rootURL = new URL(`http://192.168.50.59:5218/api/v1/comment`)

export async function GetCommentsFromPost({
  token,
  postId,
}: {
  token: string | null
  postId: number
}) {
  try {
    if (!token) throw new Error('Unauthorized')
    if (!postId) throw new Error('No post ID provided')

    const response = await request
      .get(`${rootURL}/${postId}`)
      .set('Authorization', `Bearer ${token}`)
    return response.body
  } catch (error: any) {
    throw error
  }
}
