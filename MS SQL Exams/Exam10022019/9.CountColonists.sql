select Count(*) from Colonists as c
inner join TravelCards as tc on tc.ColonistId = c.Id
inner join Journeys as j on tc.JourneyId = j.Id
where j.Purpose = 'Technical'
