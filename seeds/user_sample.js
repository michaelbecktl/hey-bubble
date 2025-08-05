/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
export async function seed(knex) {
  // Deletes ALL existing entries
  await knex('user').del()
  await knex('user').insert([
    {
      username: 'maya91',
      password: 'test',
      email: 'maya@heybubble.co.nz',
    },
    {
      username: 'alicewonder',
      password: 'test',
      email: 'alice@heybubble.co.nz',
    },
    {
      username: 'hanamorijp',
      password: 'test',
      email: 'hana@heybubble.co.nz',
    },
  ])
}
