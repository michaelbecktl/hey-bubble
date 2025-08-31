import request from 'superagent'

const rootURL = new URL(`http://192.168.50.59:5218/api/v1/post`)

export async function GetPublicPosts({ token }: { token: string | null }) {
  try {
    if (!token) throw new Error('Unauthorized')

    const response = await request
      .get(`${rootURL}`)
      .set('Authorization', `Bearer ${token}`)
    return response.body
  } catch (error: any) {
    throw error
  }
}
