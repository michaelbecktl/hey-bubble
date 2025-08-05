/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
export async function seed(knex) {
  // Deletes ALL existing entries
  await knex('user_profile').del()
  await knex('user_profile').insert([
    {
      username: 'maya91',
      display_name: 'Maya',
      dob: null,
      gender: 'Female',
      native_language: 'EN',
      learning_language: 'JP',
    },
    {
      username: 'alicewonder',
      display_name: 'Alice',
      dob: null,
      gender: 'Female',
      native_language: 'EN',
      learning_language: 'JP',
    },
    {
      username: 'hanamorijp',
      display_name: 'Hana',
      dob: null,
      gender: 'Female',
      native_language: 'JP',
      learning_language: 'EN',
    },
  ])
}
