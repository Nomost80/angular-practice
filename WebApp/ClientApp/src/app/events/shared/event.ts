export interface Event {
  id: number;
  createdAt: Date,
  updatedAt: Date,
  title: string;
  description: string;
  price: number;
  question: string,
  address: string,
  postcode: string,
  city: string,
  country: string,
  voteDeadline: Date,
  enrollmentDeadline: Date,
  date: Date,
  validatedAt: Date
}
